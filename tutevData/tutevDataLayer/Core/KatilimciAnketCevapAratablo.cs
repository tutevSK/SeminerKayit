using System;
using tutevDataLayer.Helper;
namespace tutevDataLayer.Core {

	[Serializable]
	public class KatilimciAnketCevapAratablo:BaseTable {

		public Int32 SoruId { get; set; }
 		public Int32 SecenekId { get; set; }
 
		private Int32 _KatilimciId;
		public Int32 KatilimciId
		{
			get
			{
				return this._KatilimciId;
			}
			set
			{
				this._KatilimciId = value;
				base.PrimaryKey = this._KatilimciId;
			}
		}
		public KatilimciAnketCevapAratablo() {}

		public KatilimciAnketCevapAratablo (Int32 katilimciId,Int32 soruId,Int32 secenekId) {
			this._KatilimciId=katilimciId;
			this.SoruId = soruId;
			this.SecenekId = secenekId;
		}

		public override string GetName()
		{
			return "KATILIMCI_ANKET_CEVAP_ARATABLO";
		}

		public override string ToString()
		{
			return "[KATILIMCI_ANKET_CEVAP_ARATABLO][KEY="+this._KatilimciId.ToString()+"], KATILIMCI_ID="+this.KatilimciId.ToString()+", SORU_ID="+this.SoruId.ToString()+", SECENEK_ID="+this.SecenekId.ToString()+""; 
		}

	}
}
