

#ifndef INPUTABLE_H
#define INPUTABLE_H

#include "InputMan.h"

/** Values that represent inputs. */
enum Inputs
{
	ALT_KEY = AZUL_KEY::KEY_LEFT_ALT,
	CTRL_KEY = AZUL_KEY::KEY_LEFT_CONTROL,
	SHIFT_KEY = AZUL_KEY::KEY_LEFT_SHIFT,
	SPACE_KEY = AZUL_KEY::KEY_SPACE,
	TAB_KEY = AZUL_KEY::KEY_TAB,

	F1 = AZUL_KEY::KEY_F1,
	F2,
	F3,
	F4,
	F5,
	F6,
	F7,
	F8,
	F9,
	F10,

	NUM_0 = AZUL_KEY::KEY_0,
	NUM_1 = AZUL_KEY::KEY_1,
	NUM_2 = AZUL_KEY::KEY_2,
	NUM_3 = AZUL_KEY::KEY_3,
	NUM_4 = AZUL_KEY::KEY_4,
	NUM_5 = AZUL_KEY::KEY_5,
	NUM_6 = AZUL_KEY::KEY_6,
	NUM_7 = AZUL_KEY::KEY_7,
	NUM_8 = AZUL_KEY::KEY_8,
	NUM_9 = AZUL_KEY::KEY_9,

	A_KEY = AZUL_KEY::KEY_A,
	B_KEY = AZUL_KEY::KEY_B,
	C_KEY = AZUL_KEY::KEY_C,
	D_KEY = AZUL_KEY::KEY_D,
	E_KEY = AZUL_KEY::KEY_E,
	F_KEY = AZUL_KEY::KEY_F,
	G_KEY = AZUL_KEY::KEY_G,
	H_KEY = AZUL_KEY::KEY_H,
	I_KEY = AZUL_KEY::KEY_I,
	J_KEY = AZUL_KEY::KEY_J,
	K_KEY = AZUL_KEY::KEY_K,
	L_KEY = AZUL_KEY::KEY_L,
	M_KEY = AZUL_KEY::KEY_M,
	N_KEY = AZUL_KEY::KEY_N,
	O_KEY = AZUL_KEY::KEY_O,
	P_KEY = AZUL_KEY::KEY_P,
	Q_KEY = AZUL_KEY::KEY_Q,
	R_KEY = AZUL_KEY::KEY_R,
	S_KEY = AZUL_KEY::KEY_S,
	T_KEY = AZUL_KEY::KEY_T,
	U_KEY = AZUL_KEY::KEY_U,
	V_KEY = AZUL_KEY::KEY_V,
	W_KEY = AZUL_KEY::KEY_W,
	X_KEY = AZUL_KEY::KEY_X,
	Y_KEY = AZUL_KEY::KEY_Y,
	Z_KEY = AZUL_KEY::KEY_Z

};


enum KEY_STATES;

class Inputable
{
public:

	/**
	 \brief Callback for when a watched key is pressed. If you would like to 
	 have a constant key down event, it is recommended that you use InputManager::getKeyState.
	
	 \param	input   	The input.
	 \param	shiftKey	true if shift key is pressed.
	 \param	altKey  	true if alternate key is pressed.
	 \param	ctrlKey 	true if control key is pressed.

	 \ingroup INPUTABLE
	 */
	virtual void keyPressed(Inputs input, bool shiftKey, bool altKey, bool ctrlKey){input;shiftKey;altKey;ctrlKey;}

	/**
	 \brief Callback for when a watched key is released. if you would like to have
	 a constant key up event, it is recommended that you use InputManager::getKeyState.
	
	 \param	input   	The input.
	 \param	shiftKey	true to shift key.
	 \param	altKey  	true to alternate key.
	 \param	ctrlKey 	true to control key.

	 \ingroup INPUTABLE
	 */
	virtual void keyReleased(Inputs input, bool shiftKey, bool altKey, bool ctrlKey){input;shiftKey;altKey;ctrlKey;}

	virtual void keyDown(Inputs input, bool shiftKey, bool altKey, bool ctrlKey){input;shiftKey;altKey;ctrlKey;}
	virtual void keyUp(Inputs input, bool shiftKey, bool altKey, bool ctrlKey){input;shiftKey;altKey;ctrlKey;}

protected:
	Inputable(){};
	virtual ~Inputable(){};
};

#endif // INPUTABLE_H