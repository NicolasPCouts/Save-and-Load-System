# Save-System
A simple, but yet very powerful save system that i have made using C#/.NET and generics...
I've made for using in games made with Unity, but with very few alterations you can use it for everything that you want.

How To Use:
The Player.cs Class is an example of a file that you would want to save, the class must derive From the ISaveAndLoad interface and Inplement the Save and Load methods.

To save the player's data you need to Create a class just for the data, like i did in the example file Player.cs, inside of this file you have a class called PlayerData that derives from SaveableObject, you must define a key for this class, and the class needs to be serializable.
