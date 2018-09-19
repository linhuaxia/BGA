 
using Lin.BGA.DAL;
using Lin.BGA.IDAL;
using Lin.BGA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lin.BGA.DALFactory
{
	public partial class DBSession : IDBSession
    {
	
		private IAppVersionInfoDAL _AppVersionInfoDAL;
        public IAppVersionInfoDAL AppVersionInfoDAL
        {
            get
            {
                if(_AppVersionInfoDAL == null)
                {
                    _AppVersionInfoDAL = AbstractFactory.CreateAppVersionInfoDAL();
                }
                return _AppVersionInfoDAL;
            }
            set { _AppVersionInfoDAL = value; }
        }
	
		private ICategoryInfoDAL _CategoryInfoDAL;
        public ICategoryInfoDAL CategoryInfoDAL
        {
            get
            {
                if(_CategoryInfoDAL == null)
                {
                    _CategoryInfoDAL = AbstractFactory.CreateCategoryInfoDAL();
                }
                return _CategoryInfoDAL;
            }
            set { _CategoryInfoDAL = value; }
        }
	
		private IMusicInfoDAL _MusicInfoDAL;
        public IMusicInfoDAL MusicInfoDAL
        {
            get
            {
                if(_MusicInfoDAL == null)
                {
                    _MusicInfoDAL = AbstractFactory.CreateMusicInfoDAL();
                }
                return _MusicInfoDAL;
            }
            set { _MusicInfoDAL = value; }
        }
	
		private IMusicLogInfoDAL _MusicLogInfoDAL;
        public IMusicLogInfoDAL MusicLogInfoDAL
        {
            get
            {
                if(_MusicLogInfoDAL == null)
                {
                    _MusicLogInfoDAL = AbstractFactory.CreateMusicLogInfoDAL();
                }
                return _MusicLogInfoDAL;
            }
            set { _MusicLogInfoDAL = value; }
        }
	
		private IProfilesInfoDAL _ProfilesInfoDAL;
        public IProfilesInfoDAL ProfilesInfoDAL
        {
            get
            {
                if(_ProfilesInfoDAL == null)
                {
                    _ProfilesInfoDAL = AbstractFactory.CreateProfilesInfoDAL();
                }
                return _ProfilesInfoDAL;
            }
            set { _ProfilesInfoDAL = value; }
        }
	
		private IStoreInfoDAL _StoreInfoDAL;
        public IStoreInfoDAL StoreInfoDAL
        {
            get
            {
                if(_StoreInfoDAL == null)
                {
                    _StoreInfoDAL = AbstractFactory.CreateStoreInfoDAL();
                }
                return _StoreInfoDAL;
            }
            set { _StoreInfoDAL = value; }
        }
	
		private IsysdiagramsDAL _sysdiagramsDAL;
        public IsysdiagramsDAL sysdiagramsDAL
        {
            get
            {
                if(_sysdiagramsDAL == null)
                {
                    _sysdiagramsDAL = AbstractFactory.CreatesysdiagramsDAL();
                }
                return _sysdiagramsDAL;
            }
            set { _sysdiagramsDAL = value; }
        }
	}	
}