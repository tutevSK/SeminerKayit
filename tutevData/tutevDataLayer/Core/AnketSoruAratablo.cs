using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class AnketSoruAratablo:BaseTable {

		public Int32 SoruId { get; set; }
 
		private Int32 _AnketId;
		public Int32 AnketId
		{
			get
			{
				return this._AnketId;
			}
			set
			{
				this._AnketId = value;
				base.PrimaryKey = this._AnketId;
			}
		}
		public AnketSoruAratablo() {}

		public AnketSoruAratablo (Int32 anketId,Int32 soruId) {
			this._AnketId=anketId;
			this.SoruId = soruId;
		}

		public override string GetName()
		{
			return "ANKET_SORU_ARATABLO";
		}

		public override string ToString()
		{
			return "[ANKET_SORU_ARATABLO][KEY="+this._AnketId.ToString()+"], ANKET_ID="+this.AnketId.ToString()+", SORU_ID="+this.SoruId.ToString()+""; 
		}

	}
}
