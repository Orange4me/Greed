namespace Greed.Game.Casting
{
    public class Score : Actor
    {

    private int _points;

    public Score()
    {
        
    }

    public void AddPoints(int points)
    {
        _points += points;
        SetTest($"Score: {_points}");
    }

    }
}