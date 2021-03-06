﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    public class Delay
    {

        //SOURCE (https://www.youtube.com/watch?v=kWQdCs0YrTw&feature=share&fbclid=IwAR2ngiRZcjAgUQNJ2_Iix3fJgtzD5cJlOhNj_uSDzftvS6VhuhgXmvArBQc)
        private TimeSpan delayRate;
        private TimeSpan previousCallTime;

        public Delay(float rate)
        {
            delayRate = TimeSpan.FromSeconds(rate);
            previousCallTime = TimeSpan.FromSeconds(0.0f);
        }

        public void setDelay(float rate)
        {
            delayRate = TimeSpan.FromSeconds(rate);
        }

        public float getDelay()
        {
            return (float)delayRate.TotalMilliseconds / 1000.0f;
        }

        public bool timerDone(GameTime gameTime)
        {
            if(gameTime.TotalGameTime - previousCallTime > delayRate)
            {
                previousCallTime = gameTime.TotalGameTime;
                return true;
            }
            return false;
        }
    }
}
