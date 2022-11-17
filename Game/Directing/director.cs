using System;
using System.Collections.Generic;
using Greed.Game.Casting;
using Greed.Game.Services;


namespace Greed.Game.Directing
{
    public class Director
    {
        private KeyboardService _keyboardService = null;
        private VideoService _videoService = null;

        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this._keyboardService = keyboardService;
            this._videoService = videoService;
        }

        public void StartGame(Cast cast)
        {
            _videoService.OpenWindow();
            while (_videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            _videoService.CloseWindow();
        }

        private void GetInputs(Cast cast)
        {
            Actor minor = cast.GetFirstActor("minor");
            Point velocity = _keyboardService.GetDirection();
            int x = velocity.GetX();
            int y = 0;
            velocity = new Point(x, y);
            minor.SetVelocity(velocity);     
        }

        private void DoUpdates(Cast cast)
        {
            // Delete?
            // Actor miner = cast.GetFirstActor("miner");
            // Actor score = cast.GetFirstActor("score");
            // List<Actor> Collectables = cast.GetActors("Collectables");

            // 1. spawn new collectables (randomize them)
            Random random = new Random();
            for (int i = 0; i < 23; i++)
            {
                int x = random.Next(1, 60);
                int y = 0;
                Point position = new Point (x,z);
                position = position.Scale(15);

                int vx = random.Next(-3, 5);
                int vy = random.Next(-3, 5);
                Point velocity = new Point (vx, vy);
                velocity = position.Scale(15);


                int r = random.Next(0,256);
                int g = random.Next(0,256);
                int b = random.Next(0,256);

                Color color = new Color (r, g, b);

                string Symbol = "*";
                int points = 20;
                int isRock = random.Next(0,2);
                if (isRock ==1);
                    {
                        symbol = "@";
                        points = -20;
                    }

                Score collectable= new Collectable();
                collectable.SetText (symbol);
                collectable.SetFontSize(15);
                collectable.SetColor(color);
                collectable.SetPosition(position);
                collectable.SetVelocity(new Point (0, 3));
                collectable.SetPoints(points);
                cast.AddActor("collectables", collectable);


            }
            // 2. handle collisions between the minor and the collectables

            Actor miner = cast.GetFirstActor("miner");
            Actor score = cast.GetFirstActor("score");
            List<Actor> collectables = cast.GetActors("collectables");



            // 3. Move all the actors
            
            int maxX = _videoService.GetWidth();
            int maxY = _videoService.GetHeight();

            miner.MoveNext (maxX, maxY);
            foreach (Actor collectable in collectables)
            {
                collectables.MoveNext (maxX, maxY);
            }
            // 4. handle collisions between the minor and collectables
            foreach (Actor collectable in collectables)
            {
                if (miner.GetPosition().Equals(collectable.GetPosition()))
                {
                    // TODO: Create the score class
            
                    int points = ((Score) collectable).GetPoints();
                    ((Score)score).AddPoints(points);
                    cast.RemoveActor("collectables"), collectables;
                }

            public void DoOutputs(Cast cast)
            {
                List<Actors> actors = cast.GetActors("collectables");

            }


            banner.SetText("");
            int maxX = _videoService.GetWidth();
            int maxY = _videoService.GetHeight();
            robot.MoveNext(maxX, maxY);

            foreach (Actor collectable in collectables)
            {
                if (robot.GetPosition().Equals(collectable.GetPosition()))
                {
                    Artifact artifact = (Artifact) collectable;
                    string message = artifact.GetMessage();
                    banner.SetText(message);
                }
            } 
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            _videoService.ClearBuffer();
            _videoService.DrawActors(actors);
            _videoService.FlushBuffer();
        }

    }
}

