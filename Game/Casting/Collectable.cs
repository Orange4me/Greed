namespace Greed.Game.Casting
{
    public class Score : Actor
    {

    private int _points;

    public Score()
    {

    }
    public int GetPoints()
    {
        return _points;
    }

    public void SetPoints(int points)
    {
        _points = points;
    }

    }
}