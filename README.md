# Save-System
A simple, but yet very powerful save system that i have made using C#/.NET and generics...
I've made for using in games made with Unity, but with very few alterations you can use it for everything that you want.

How To Use:
The Player.cs Class is an example of a file that you would want to save, the class must derive From the ISaveAndLoad interface and Inplement the Save and Load methods.

To save the player's data you need to Create a class just for the data, like i did in the example file Player.cs, inside of this file you have a class called PlayerData that derives from SaveableObject, you must define a key for this class, i used in this example "Player" as the key, but you can create any key that you want, and the class needs to be serializable.

IF YOU ARE using this save system for a Unity game, you must implement the GetPrefabPath() and IsInstantiable() methods, these are the methods that you will use to define if you want to Instantiate the Object when loading the game or not.

IF YOU ARE NOT using this save system for a Unity game, you can just delete these methods from the SaveableObject class.


The Saving Manager is where all the magic happens, the first thing that you want to do when you acess this script is to define de SavingPath variable, you need to define a path to save your files.

After defining the path to save your files, you are ready to go. you can save your data by calling the SaveData<>() method in the player class or any class the you create that derives from ISaveAndLoad interface and passing 2 arguments.

The first argument(or parameter) is the  dataToSave, this would be your PlayerData class or any class that you create that derives form SaveableObject.

And the second argument is an integer called Save, this parameter is useful if you want to have multiple save files, but if you just want to have one save file, you can pass the number 1(or any number that you want) to the argument.

If want to load the file, is basically the same process, first you need to call the LoadData<>() method in the player class or any class the you create that derives from ISaveAndLoad interface.
In the first argument you pass the key, in this example case the key would be "Player", and the second parameter you need to put the same number that you put in the SaveData<>() method.
