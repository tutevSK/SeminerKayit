using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class Soru:BaseTable {

		public String SoruMetni { get; set; }
 		public Int32 SecenekTip { get; set; }
 
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
		public Soru() {}

		public Soru (Int32 id,String soruMetni,Int32 secenekTip) {
			this._Id=id;
			this.SoruMetni = soruMetni;
			this.SecenekTip = secenekTip;
		}

		public override string GetName()
		{
			return "SORU";
		}

		public override string ToString()
		{
			return "[SORU][KEY="+this._Id.ToString()+"], ID="+this.Id.ToString()+", SORU_METNI="+this.SoruMetni+", SECENEK_TIP="+this.SecenekTip.ToString()+""; 
		}

	}
}
