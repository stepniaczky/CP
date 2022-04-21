using System;

namespace Data
{
    public abstract class AbstractDataApi
    {

        public AbstractDataApi CreateApi()
        {
            return new DataApi();
        }

        internal class DataApi : AbstractDataApi
        {

        }
    }
}
