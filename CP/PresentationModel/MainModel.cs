using System;
using System.Collections.Generic;
using System.Text;
using Logic;

namespace PresentationModel
{
    internal class ModelApi : ModelAbstractApi
    {
        private LogicApi LogicLayer = LogicApi.CreateApi();
        private readonly int _width;
        private readonly int _height;
        public int Width { get =>  _width; } 
        public int Height { get => _height; }

        public override int Radius => 1/14 * Height;  //TODO responsiveness
        public ModelApi() : this(LogicApi.CreateApi(Width, Height, Radius))
        {
        }

        public ModelApi(LogicApi logicApi)
        {
            LogicLayer = logicApi;
        }

        public override void CreateBalls(int ballsNumber)
        {
            return _logicApi.CreateBalls();
        }

        public override List<object> GetBalls()
        {
            return _logicApi.GetBalls();
        }

        public override void ClearBalls()
        {
            return _logicApi.ClearBalls();
        }
    }
}
