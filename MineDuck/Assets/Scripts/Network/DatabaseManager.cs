using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using Proyecto26;
using System.Net;
using UnityEngine;

public class DatabaseManager
{
    private const string projectId = "mineduck-b7ab5";
    private static readonly string databaseURL = $"https://{projectId}.firebaseio.com/";
    public delegate void GetUserCallback(User user);

    public static DatabaseReference GetDatabaseRef()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://mineduck-b7ab5.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        return reference;
    }

    public static void PostUserToDatabase(User user)
    {
        RestClient.Put<User>($"{databaseURL}users/" + user.nickname + ".json", user);
    }

    public static void GetUser(string userName, GetUserCallback callback)
    {
        RestClient.Get<User>($"{databaseURL}users/" + userName + ".json").Then(user =>
        { callback(user); });
    }

    public static void SetCoins(int coins)
    {
        DatabaseReference reference = GetDatabaseRef();
        reference.Child("users").Child(Constants.NICKNAME).Child("coins").SetValueAsync(coins);
    }

    public static void SetDiamonds(int diamonds)
    {
        DatabaseReference reference = GetDatabaseRef();
        reference.Child("users").Child(Constants.NICKNAME).Child("diamonds").SetValueAsync(diamonds);
    }

    public static void SetCurrentDuck(string duckName)
    {
        DatabaseReference reference = GetDatabaseRef();
        reference.Child("users").Child(Constants.NICKNAME).Child("currentDuck").SetValueAsync(duckName);
    }

    public static bool HasInternetConnection()
    {
        try
        {
            using (var client = new WebClient())
            using (var stream = client.OpenRead("http://www.google.com"))
            {
                Debug.Log("true");
                return true;
            }
        }
        catch
        {
            Debug.Log("false");
            return false;
        }
    }
}