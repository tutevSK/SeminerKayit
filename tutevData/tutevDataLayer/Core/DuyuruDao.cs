using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class DuyuruDao:BaseDbDao {

		private Duyuru nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public DuyuruDao() {}

		public int Insert(Duyuru nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO DUYURU (DUYURU_TIP_ID,ORGANIZASYON_ID,BASLIK,BITIS_TARIHI)VALUES(@duyuruTipId,@organizasyonId,@baslik,@bitisTarihi)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@duyuruTipId", DbType.Int32, nesne.DuyuruTipId==null?(object)DBNull.Value:nesne.DuyuruTipId);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, nesne.OrganizasyonId==null?(object)DBNull.Value:nesne.OrganizasyonId);
			db.AddInParameter(dbComm, "@baslik", DbType.String, nesne.Baslik==null?(object)DBNull.Value:nesne.Baslik);
			db.AddInParameter(dbComm, "@bitisTarihi", DbType.DateTime, nesne.BitisTarihi==null?(object)DBNull.Value:nesne.BitisTarihi);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(Duyuru nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE DUYURU set DUYURU_TIP_ID = @duyuruTipId , ORGANIZASYON_ID = @organizasyonId , BASLIK = @baslik , BITIS_TARIHI = @bitisTarihi WHERE ID = @id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@duyuruTipId", DbType.Int32, nesne.DuyuruTipId==null?(object)DBNull.Value:nesne.DuyuruTipId);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, nesne.OrganizasyonId==null?(object)DBNull.Value:nesne.OrganizasyonId);
			db.AddInParameter(dbComm, "@baslik", DbType.String, nesne.Baslik==null?(object)DBNull.Value:nesne.Baslik);
			db.AddInParameter(dbComm, "@bitisTarihi", DbType.DateTime, nesne.BitisTarihi==null?(object)DBNull.Value:nesne.BitisTarihi);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int id,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE DUYURU where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			Duyuru nesne = new Duyuru();
			nesne.Id = id;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public Duyuru GetById(int id,Database db){
 			nesne = new Duyuru();
			sqlText="Select ID,DUYURU_TIP_ID,ORGANIZASYON_ID,BASLIK,BITIS_TARIHI from DUYURU where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillDuyuru(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,DUYURU_TIP_ID,ORGANIZASYON_ID,BASLIK,BITIS_TARIHI from DUYURU "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,DUYURU_TIP_ID,ORGANIZASYON_ID,BASLIK,BITIS_TARIHI from DUYURU "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<Duyuru> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,DUYURU_TIP_ID,ORGANIZASYON_ID,BASLIK,BITIS_TARIHI from DUYURU "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Duyuru> duyuruList = new List<Duyuru>();
				while(reader.Read()){
					Duyuru duyuru = FillDuyuru(reader);
					duyuruList.Add( duyuru);
				}
				return duyuruList;
			}
		}

		public DataSet GetByAll(string OrderBy,Int32 DuyuruTipId,Int32 OrganizasyonId,String Baslik,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ID,DUYURU_TIP_ID,ORGANIZASYON_ID,BASLIK,BITIS_TARIHI from DUYURU Where 1=1 
 						 and (DUYURU_TIP_ID = @duyuruTipId or @duyuruTipId =-1)
						 and (ORGANIZASYON_ID = @organizasyonId or @organizasyonId =-1)
						 and (BASLIK like @baslik or @baslik ='')
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@duyuruTipId", DbType.Int32, DuyuruTipId);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, OrganizasyonId);
			db.AddInParameter(dbComm, "@baslik", DbType.String, Baslik);
			return db.ExecuteDataSet(dbComm);
		}


		public Duyuru FillDuyuru(IDataReader reader){
 			nesne = new Duyuru();
			nesne.Id=(Int32)reader["ID"];
			nesne.DuyuruTipId=(Int32)reader["DUYURU_TIP_ID"];
			nesne.OrganizasyonId=(Int32)reader["ORGANIZASYON_ID"];
			nesne.Baslik=(String)reader["BASLIK"];
			nesne.BitisTarihi=(DateTime)reader["BITIS_TARIHI"];
			return nesne;
		}

		public DataSet GetByDuyuruTipId(string OrderBy,Int32 duyuruTipId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,DUYURU_TIP_ID,ORGANIZASYON_ID,BASLIK,BITIS_TARIHI from DUYURU Where DUYURU_TIP_ID=@duyuruTipId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@duyuruTipId", DbType.Int32, duyuruTipId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetByDuyuruTipIdReader(string OrderBy,Int32 duyuruTipId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,DUYURU_TIP_ID,ORGANIZASYON_ID,BASLIK,BITIS_TARIHI from DUYURU Where DUYURU_TIP_ID=@duyuruTipId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@duyuruTipId", DbType.Int32, duyuruTipId);
			return db.ExecuteReader(dbComm);
		}

		public List<Duyuru> GetByDuyuruTipIdList (string OrderBy,Int32 duyuruTipId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,DUYURU_TIP_ID,ORGANIZASYON_ID,BASLIK,BITIS_TARIHI from DUYURU Where DUYURU_TIP_ID=@duyuruTipId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@duyuruTipId", DbType.Int32, duyuruTipId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Duyuru> duyuruList = new List<Duyuru>();
				while(reader.Read()){
					Duyuru duyuru = FillDuyuru(reader);
					duyuruList.Add( duyuru);
				}
				return duyuruList;
			}
		}

		public int DeleteByDuyuruTipId(Int32 duyuruTipId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE DUYURU where DUYURU_TIP_ID=@duyuruTipId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@duyuruTipId", DbType.Int32, duyuruTipId);
			Duyuru nesne=new Duyuru();
			nesne.Id=-1;
			nesne.DuyuruTipId=duyuruTipId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public DataSet GetByOrganizasyonId(string OrderBy,Int32 organizasyonId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,DUYURU_TIP_ID,ORGANIZASYON_ID,BASLIK,BITIS_TARIHI from DUYURU Where ORGANIZASYON_ID=@organizasyonId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, organizasyonId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetByOrganizasyonIdReader(string OrderBy,Int32 organizasyonId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,DUYURU_TIP_ID,ORGANIZASYON_ID,BASLIK,BITIS_TARIHI from DUYURU Where ORGANIZASYON_ID=@organizasyonId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, organizasyonId);
			return db.ExecuteReader(dbComm);
		}

		public List<Duyuru> GetByOrganizasyonIdList (string OrderBy,Int32 organizasyonId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,DUYURU_TIP_ID,ORGANIZASYON_ID,BASLIK,BITIS_TARIHI from DUYURU Where ORGANIZASYON_ID=@organizasyonId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, organizasyonId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Duyuru> duyuruList = new List<Duyuru>();
				while(reader.Read()){
					Duyuru duyuru = FillDuyuru(reader);
					duyuruList.Add( duyuru);
				}
				return duyuruList;
			}
		}

		public int DeleteByOrganizasyonId(Int32 organizasyonId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE DUYURU where ORGANIZASYON_ID=@organizasyonId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonId", DbType.Int32, organizasyonId);
			Duyuru nesne=new Duyuru();
			nesne.Id=-1;
			nesne.OrganizasyonId=organizasyonId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}
	}
}
