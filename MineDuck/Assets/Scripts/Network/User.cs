public class User
{
    public string nickname;
    public int _id;
    public int coins;
    public int diamonds;
    public string currentDuck;

    public User(string nickname,string currentDuck,int id,int coins,int diamonds)
    {
        this.nickname = nickname;
        this.currentDuck = currentDuck;
        this._id = id;
        this.coins = coins;
        this.diamonds = diamonds;
    }
}