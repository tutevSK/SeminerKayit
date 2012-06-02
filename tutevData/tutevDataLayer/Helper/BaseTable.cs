using System;

namespace tutevDataLayer.Helper
{
    [Serializable]
    public class BaseTable : Object
    {
        public virtual Object PrimaryKey { get; set; }
        public virtual string GetName() { return ""; }
        public BaseTable()
        {
        }
    }
}
