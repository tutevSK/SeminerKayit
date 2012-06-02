using System; 
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using tutevDataLayer.Controller;

namespace tutevDataLayer.Core {

	public class OrganizasyonDao:BaseDbDao {

		private Organizasyon nesne;
		private string sqlText;
		private string orderBy;
		private DbCommand dbComm = null;

		public OrganizasyonDao() {}

		public int Insert(Organizasyon nesne,DbTransaction dbTransaction,Database db){
 			sqlText="INSERT INTO ORGANIZASYON (ORGANIZASYON_TIP_ID,KULUP_ID,AD,TARIH)VALUES(@organizasyonTipId,@kulupId,@ad,@tarih)SELECT @@IDENTITY";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonTipId", DbType.Int32, nesne.OrganizasyonTipId==null?(object)DBNull.Value:nesne.OrganizasyonTipId);
			db.AddInParameter(dbComm, "@kulupId", DbType.Int32, nesne.KulupId==null?(object)DBNull.Value:nesne.KulupId);
			db.AddInParameter(dbComm, "@ad", DbType.String, nesne.Ad==null?(object)DBNull.Value:nesne.Ad);
			db.AddInParameter(dbComm, "@tarih", DbType.DateTime, nesne.Tarih==null?(object)DBNull.Value:nesne.Tarih);
			return base.Insert(nesne, dbComm, dbTransaction, db);
		}

		public int Update(Organizasyon nesne,DbTransaction dbTransaction,Database db){
 			sqlText=" UPDATE ORGANIZASYON set ORGANIZASYON_TIP_ID = @organizasyonTipId , KULUP_ID = @kulupId , AD = @ad , TARIH = @tarih WHERE ID = @id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, nesne.Id==null?(object)DBNull.Value:nesne.Id);
			db.AddInParameter(dbComm, "@organizasyonTipId", DbType.Int32, nesne.OrganizasyonTipId==null?(object)DBNull.Value:nesne.OrganizasyonTipId);
			db.AddInParameter(dbComm, "@kulupId", DbType.Int32, nesne.KulupId==null?(object)DBNull.Value:nesne.KulupId);
			db.AddInParameter(dbComm, "@ad", DbType.String, nesne.Ad==null?(object)DBNull.Value:nesne.Ad);
			db.AddInParameter(dbComm, "@tarih", DbType.DateTime, nesne.Tarih==null?(object)DBNull.Value:nesne.Tarih);
			return base.Update(nesne, dbComm, dbTransaction, db);
		}

		public int Delete(int id,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE ORGANIZASYON where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			Organizasyon nesne = new Organizasyon();
			nesne.Id = id;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public Organizasyon GetById(int id,Database db){
 			nesne = new Organizasyon();
			sqlText="Select ID,ORGANIZASYON_TIP_ID,KULUP_ID,AD,TARIH from ORGANIZASYON where ID=@id ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@id", DbType.Int32, id);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				if(reader.Read()){
					nesne = FillOrganizasyon(reader);
				}else nesne=null;
			}
			return nesne;
		}

		public DataSet GetAll(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_TIP_ID,KULUP_ID,AD,TARIH from ORGANIZASYON "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetAllReader(string OrderBy, Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_TIP_ID,KULUP_ID,AD,TARIH from ORGANIZASYON "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			return db.ExecuteReader(dbComm);
		}

		public List<Organizasyon> GetAllList(string OrderBy,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_TIP_ID,KULUP_ID,AD,TARIH from ORGANIZASYON "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Organizasyon> organizasyonList = new List<Organizasyon>();
				while(reader.Read()){
					Organizasyon organizasyon = FillOrganizasyon(reader);
					organizasyonList.Add( organizasyon);
				}
				return organizasyonList;
			}
		}

		public DataSet GetByAll(string OrderBy,Int32 OrganizasyonTipId,Int32 KulupId,String Ad,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText=@"Select ID,ORGANIZASYON_TIP_ID,KULUP_ID,AD,TARIH from ORGANIZASYON Where 1=1 
 						 and (ORGANIZASYON_TIP_ID = @organizasyonTipId or @organizasyonTipId =-1)
						 and (KULUP_ID = @kulupId or @kulupId =-1)
						 and (AD like @ad or @ad ='')
						"+orderBy;
			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonTipId", DbType.Int32, OrganizasyonTipId);
			db.AddInParameter(dbComm, "@kulupId", DbType.Int32, KulupId);
			db.AddInParameter(dbComm, "@ad", DbType.String, Ad);
			return db.ExecuteDataSet(dbComm);
		}


		public Organizasyon FillOrganizasyon(IDataReader reader){
 			nesne = new Organizasyon();
			nesne.Id=(Int32)reader["ID"];
			nesne.OrganizasyonTipId=(Int32)reader["ORGANIZASYON_TIP_ID"];
			nesne.KulupId=(Int32)reader["KULUP_ID"];
			nesne.Ad=(String)reader["AD"];
			nesne.Tarih=(DateTime)reader["TARIH"];
			return nesne;
		}

		public DataSet GetByOrganizasyonTipId(string OrderBy,Int32 organizasyonTipId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_TIP_ID,KULUP_ID,AD,TARIH from ORGANIZASYON Where ORGANIZASYON_TIP_ID=@organizasyonTipId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonTipId", DbType.Int32, organizasyonTipId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetByOrganizasyonTipIdReader(string OrderBy,Int32 organizasyonTipId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_TIP_ID,KULUP_ID,AD,TARIH from ORGANIZASYON Where ORGANIZASYON_TIP_ID=@organizasyonTipId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonTipId", DbType.Int32, organizasyonTipId);
			return db.ExecuteReader(dbComm);
		}

		public List<Organizasyon> GetByOrganizasyonTipIdList (string OrderBy,Int32 organizasyonTipId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_TIP_ID,KULUP_ID,AD,TARIH from ORGANIZASYON Where ORGANIZASYON_TIP_ID=@organizasyonTipId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonTipId", DbType.Int32, organizasyonTipId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Organizasyon> organizasyonList = new List<Organizasyon>();
				while(reader.Read()){
					Organizasyon organizasyon = FillOrganizasyon(reader);
					organizasyonList.Add( organizasyon);
				}
				return organizasyonList;
			}
		}

		public int DeleteByOrganizasyonTipId(Int32 organizasyonTipId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE ORGANIZASYON where ORGANIZASYON_TIP_ID=@organizasyonTipId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@organizasyonTipId", DbType.Int32, organizasyonTipId);
			Organizasyon nesne=new Organizasyon();
			nesne.Id=-1;
			nesne.OrganizasyonTipId=organizasyonTipId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}

		public DataSet GetByKulupId(string OrderBy,Int32 kulupId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_TIP_ID,KULUP_ID,AD,TARIH from ORGANIZASYON Where KULUP_ID=@kulupId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@kulupId", DbType.Int32, kulupId);
			return db.ExecuteDataSet(dbComm);
		}

		public IDataReader GetByKulupIdReader(string OrderBy,Int32 kulupId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_TIP_ID,KULUP_ID,AD,TARIH from ORGANIZASYON Where KULUP_ID=@kulupId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@kulupId", DbType.Int32, kulupId);
			return db.ExecuteReader(dbComm);
		}

		public List<Organizasyon> GetByKulupIdList (string OrderBy,Int32 kulupId,Database db){
 			orderBy = "";
			if (OrderBy.Length > 0) orderBy = " Order By " + OrderBy;
			sqlText="Select ID,ORGANIZASYON_TIP_ID,KULUP_ID,AD,TARIH from ORGANIZASYON Where KULUP_ID=@kulupId "+orderBy;
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@kulupId", DbType.Int32, kulupId);
			using (IDataReader reader = db.ExecuteReader(dbComm)){
				List<Organizasyon> organizasyonList = new List<Organizasyon>();
				while(reader.Read()){
					Organizasyon organizasyon = FillOrganizasyon(reader);
					organizasyonList.Add( organizasyon);
				}
				return organizasyonList;
			}
		}

		public int DeleteByKulupId(Int32 kulupId,DbTransaction dbTransaction,Database db){
 			sqlText="DELETE ORGANIZASYON where KULUP_ID=@kulupId ";
 			dbComm = db.GetSqlStringCommand(sqlText);
			db.AddInParameter(dbComm, "@kulupId", DbType.Int32, kulupId);
			Organizasyon nesne=new Organizasyon();
			nesne.Id=-1;
			nesne.KulupId=kulupId;
			return base.Delete(nesne, dbComm, dbTransaction, db);
		}
	}
}
