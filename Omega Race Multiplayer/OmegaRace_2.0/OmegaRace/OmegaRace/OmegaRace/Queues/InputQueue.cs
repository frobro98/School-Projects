using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Net;

using CollisionManager;

namespace OmegaRace
{
    enum HeaderType
    {
        Location,
        Input
    }

    struct QueueHdr
    {
        public HeaderType type;
        public object pHdr;
    }

    class InputQueue
    {
        private static InputQueue iqInstance = null;
        private Queue<QueueHdr> inQueue;
        private PacketReader packetReader;

        private InputQueue()
        {
            inQueue = new Queue<QueueHdr>();
            packetReader = new PacketReader();
        }

        public static void pushHeader(QueueHdr hdr)
        {
            Instance.inQueue.Enqueue(hdr);
        }
        public static void updateInfo()
        {
            if (Game1.Network.IsNetworked)
            {
                foreach (LocalNetworkGamer gamer in Game1.Network.Session.LocalGamers)
                {
                    Instance.PullNetworkData(gamer);
                }
            }

            while (Instance.inQueue.Count > 0)
            {
                QueueHdr hdr = Instance.inQueue.Dequeue();

                switch (hdr.type)
                {
                    default:
                    case HeaderType.Input:
                        InputHdr iHdr = (InputHdr)hdr.pHdr;
                        InputManager.pushInput(ref iHdr);
                        break;
                    case HeaderType.Location:
                        LocationHdr lHdr = (LocationHdr)hdr.pHdr;
                        Instance.locationUpdate(lHdr);
                        break;
                }
            }

            InputManager.process();
        }

        private void PullNetworkData(LocalNetworkGamer gamer)
        {

            //if (Game1.Network.Session.IsHost)
            //{
            //    ServerRead(gamer);
            //}
            //else
            //{
            //    ClientRead(gamer);
            //}

            ServerRead(gamer);
           
        }

        private void ServerRead(LocalNetworkGamer gamer)
        {
            while (gamer.IsDataAvailable)
            {
                NetworkGamer sender;

                gamer.ReceiveData(packetReader, out sender);

                if (!sender.IsLocal)
                {
                    QueueHdr hdr;
                    hdr.pHdr = null;

                    int type = packetReader.ReadInt32();
                    HeaderType enumType = (HeaderType)type;
                    hdr.type = enumType;
                    switch (enumType)
                    {
                        default:
                        case HeaderType.Location:
                            LocationHdr lHdr;
                            lHdr.goIndex = packetReader.ReadInt32();
                            lHdr.position = packetReader.ReadVector2();
                            lHdr.rotation = packetReader.ReadSingle();
                            lHdr.networked = true;
                            hdr.pHdr = lHdr;
                            break;
                        case HeaderType.Input:
                            InputHdr iHdr;
                            iHdr.networked = false;
                            int iType = packetReader.ReadInt32();
                            int pID = packetReader.ReadInt32();
                            iHdr.input = (InputType)iType;
                            iHdr.player = (PlayerID)pID;
                            if (iHdr.input == InputType.Collision)
                            {
                                ColHdr cHdr;
                                cHdr.goID1 = packetReader.ReadInt32();
                                cHdr.goID2 = packetReader.ReadInt32();
                                cHdr.pos = packetReader.ReadVector2();
                                iHdr.colInfo = cHdr;
                            }
                            else
                            {
                                iHdr.colInfo = null;
                            }
                            hdr.pHdr = iHdr;
                            break;
                    }

                    Debug.Assert(hdr.pHdr != null);
                    this.inQueue.Enqueue(hdr);

                }
            }
        }

        private void ClientRead(LocalNetworkGamer gamer)
        {
            while (gamer.IsDataAvailable)
            {
                NetworkGamer sender;

                gamer.ReceiveData(packetReader, out sender);

                
                    QueueHdr hdr;
                    hdr.pHdr = null;

                    int type = packetReader.ReadInt32();
                    HeaderType enumType = (HeaderType)type;
                    hdr.type = enumType;
                    switch (enumType)
                    {
                        default:
                        case HeaderType.Location:
                            LocationHdr lHdr;
                            lHdr.goIndex = packetReader.ReadInt32();
                            lHdr.position = packetReader.ReadVector2();
                            lHdr.rotation = packetReader.ReadSingle();
                            lHdr.networked = false;
                            hdr.pHdr = lHdr;
                            break;
                        case HeaderType.Input:
                            InputHdr iHdr;
                            int iType = packetReader.ReadInt32();
                            int pID = packetReader.ReadInt32();
                            iHdr.input = (InputType)iType;
                            iHdr.player = (PlayerID)pID;
                            if (iHdr.input == InputType.Collision)
                            {
                                ColHdr cHdr;
                                cHdr.goID1 = packetReader.ReadInt32();
                                cHdr.goID2 = packetReader.ReadInt32();
                                cHdr.pos = packetReader.ReadVector2();
                                iHdr.colInfo = cHdr;
                            }
                            break;
                    }

                    this.inQueue.Enqueue(hdr);
                

            
            }
        }

        private void locationUpdate(LocationHdr hdr)
        {
            GameObject node = GameObjManager.Instance().findFromIndex(hdr.goIndex);

            if(node != null)
                node.doWork(hdr);
        }
        
        private static InputQueue Instance
        {
            get
            {
                if (iqInstance == null)
                {
                    iqInstance = new InputQueue();
                }

                return iqInstance;
            }
        }
    }
}
