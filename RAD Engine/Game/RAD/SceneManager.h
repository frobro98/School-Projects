
#ifndef SCENEMANAGER_H
#define SCENEMANAGER_H

class Scene;

class SceneManager
{
public:

	/**
	 \brief Initializes the start Scene for the entire game.
	
	 \param startScene			The start Scene
	 \ingroup SCENE
	 */
	static void initialize(Scene* startScene);
	static Scene* getCurrScene();

	/**
	 \brief Changes Scene. Deletes the previous Scene entirely.
	
	 \param	newScene			pointer to the new Scene.
	 \ingroup SCENE
	 */
	static void changeScene(Scene* newScene);
	static void Update();
	static void Draw();
private:
	static SceneManager& instance();
	Scene* currScene;
	Scene* nextScene;

	void Initialize(Scene* sc);
	void toNextScene();

	SceneManager(){}
	SceneManager(const SceneManager& sm){sm;};
	const SceneManager& operator=(const SceneManager& sm){sm;};
	~SceneManager();
	
};

#endif // SCENEMANAGER_H