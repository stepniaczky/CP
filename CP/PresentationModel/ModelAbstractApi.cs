using System;
using System.Collections.Generic;
using Logic;

namespace PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract int Radius { get; }



        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }
    }

    internal class ModelApi : ModelAbstractApi
    {
        public override int Radius => 100;

        public Ball GetBall(int x, int y) => new Logic.Ball(x, y, Radius);
    }
}
