using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class Secenek:BaseTable {

		public String Aciklama { get; set; }
 
		private Int32 _Id;
		public Int32 Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				this._Id = value;
				base.PrimaryKey = this._Id;
			}
		}
		public Secenek() {}

		public Secenek (Int32 id,String aciklama) {
			this._Id=id;
			this.Aciklama = aciklama;
		}

		public override string GetName()
		{
			return "SECENEK";
		}

		public override string ToString()
		{
			return "[SECENEK][KEY="+this._Id.ToString()+"], ID="+this.Id.ToString()+", ACIKLAMA="+this.Aciklama+""; 
		}

	}
}
