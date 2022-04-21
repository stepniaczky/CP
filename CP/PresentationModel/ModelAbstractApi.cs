using System;
using System.Collections.Generic;
using Logic;

namespace PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }
        public abstract int Radius { get; }

        public abstract void CreateBalls(int ballsNumber);

        public abstract List<Object> GetBalls();

        public abstract void ClearBalls();
    }
}

