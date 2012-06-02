using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class SecenekTip:BaseTable {

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
		public SecenekTip() {}

		public SecenekTip (Int32 id,String aciklama) {
			this._Id=id;
			this.Aciklama = aciklama;
		}

		public override string GetName()
		{
			return "SECENEK_TIP";
		}

		public override string ToString()
		{
			return "[SECENEK_TIP][KEY="+this._Id.ToString()+"], ID="+this.Id.ToString()+", ACIKLAMA="+this.Aciklama+""; 
		}

	}
}
