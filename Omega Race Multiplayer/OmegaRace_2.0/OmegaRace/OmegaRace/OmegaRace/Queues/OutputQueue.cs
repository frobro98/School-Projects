using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Net;

using CollisionManager;

namespace OmegaRace
{
    class OutputQueue
    {
        private static OutputQueue oqInstance = null;
        private Queue<QueueHdr> outQueue;
        private PacketWriter packetWriter;

        private OutputQueue()
        {
            outQueue = new Queue<QueueHdr>();
            packetWriter = new PacketWriter();
        }

        public static void pushHeader(ref LocationHdr lHdr)
        {
            QueueHdr hdr;
            hdr.type = HeaderType.Location;
            hdr.pHdr = lHdr;

            Instance.outQueue.Enqueue(hdr);
        }

        public static void pushHeader(InputHdr iHdr)
        {
            QueueHdr hdr;
            hdr.type = HeaderType.Input;
            hdr.pHdr = iHdr;

            Instance.outQueue.Enqueue(hdr);
        }

        private void PushToNetwork(LocalNetworkGamer gamer)
        {
            if (Game1.Network.Session.IsHost)
            {
                UpdateServer(gamer);
            }
            else
            {
                UpdateLocalGamer(gamer);
            }
        }

        private void UpdateServer(LocalNetworkGamer gamer)
        {
            LocalNetworkGamer server = (LocalNetworkGamer)Game1.Network.Session.Host;

            while (outQueue.Count > 0)
            {
                QueueHdr hdr = outQueue.Dequeue();

                switch (hdr.type)
                {
                    default:
                    case HeaderType.Location:
                        int lType = (int)hdr.type;
                        LocationHdr lHdr = (LocationHdr)hdr.pHdr;
                        packetWriter.Write(lType);
                        packetWriter.Write(lHdr.goIndex);
                        packetWriter.Write(lHdr.position);
                        packetWriter.Write(lHdr.rotation);
                        break;
                    case HeaderType.Input:
                        int iType = (int)hdr.type;
                        InputHdr iHdr = (InputHdr)hdr.pHdr;
                        packetWriter.Write(iType);
                        packetWriter.Write((int)iHdr.input);
                        packetWriter.Write((int)iHdr.player);
                        if (iHdr.input == InputType.Collision)
                        {
                            ColHdr cHdr = (ColHdr)iHdr.colInfo;
                            packetWriter.Write(cHdr.goID1);
                            packetWriter.Write(cHdr.goID2);
                            packetWriter.Write(cHdr.pos);
                        }
                        break;
                }

                server.SendData(packetWriter, SendDataOptions.InOrder);
            }

        }

        private void UpdateLocalGamer(LocalNetworkGamer gamer)
        {
            while (outQueue.Count > 0)
            {
                QueueHdr hdr = outQueue.Dequeue();

                switch (hdr.type)
                {
                    default:
                    case HeaderType.Location:
                        int lType = (int)hdr.type;
                        LocationHdr lHdr = (LocationHdr)hdr.pHdr;
                        packetWriter.Write(lType);
                        packetWriter.Write(lHdr.goIndex);
                        packetWriter.Write(lHdr.position);
                        packetWriter.Write(lHdr.rotation);
                        break;
                    case HeaderType.Input:
                        int iType = (int)hdr.type;
                        InputHdr iHdr = (InputHdr)hdr.pHdr;
                        packetWriter.Write(iType);
                        packetWriter.Write((int)iHdr.input);
                        packetWriter.Write((int)iHdr.player);
                        if (iHdr.input == InputType.Collision)
                        {
                            ColHdr cHdr = (ColHdr)iHdr.colInfo;
                            packetWriter.Write(cHdr.goID1);
                            packetWriter.Write(cHdr.goID2);
                            packetWriter.Write(cHdr.pos);
                        }
                        break;
                }

                gamer.SendData(packetWriter, SendDataOptions.InOrder, Game1.Network.Session.Host);
            }
            
        }

        public static void flush()
        {
            Queue<QueueHdr> tmpQ = Instance.outQueue;


            foreach(QueueHdr hdr in tmpQ)
            {
                InputQueue.pushHeader(hdr);
            }
            
            if(Game1.Network.IsNetworked)
            {
                foreach (LocalNetworkGamer gamer in Game1.Network.Session.LocalGamers)
                {
                    Instance.PushToNetwork(gamer);
                }
            }
        }

        private static OutputQueue Instance
        {
            get
            {
                if (oqInstance == null)
                {
                    oqInstance = new OutputQueue();
                }

                return oqInstance;
            }
        }
    }
}
