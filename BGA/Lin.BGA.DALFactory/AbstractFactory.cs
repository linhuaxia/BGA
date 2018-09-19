 

using Lin.BGA.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lin.BGA.DALFactory
{
    public partial class AbstractFactory
    {
      
   
		
	    public static IAppVersionInfoDAL CreateAppVersionInfoDAL()
        {

		 string fullClassName = AssemblyNameSpace + ".AppVersionInfoDAL";
          return CreateInstance(fullClassName) as IAppVersionInfoDAL;

        }
		
	    public static ICategoryInfoDAL CreateCategoryInfoDAL()
        {

		 string fullClassName = AssemblyNameSpace + ".CategoryInfoDAL";
          return CreateInstance(fullClassName) as ICategoryInfoDAL;

        }
		
	    public static IMusicInfoDAL CreateMusicInfoDAL()
        {

		 string fullClassName = AssemblyNameSpace + ".MusicInfoDAL";
          return CreateInstance(fullClassName) as IMusicInfoDAL;

        }
		
	    public static IMusicLogInfoDAL CreateMusicLogInfoDAL()
        {

		 string fullClassName = AssemblyNameSpace + ".MusicLogInfoDAL";
          return CreateInstance(fullClassName) as IMusicLogInfoDAL;

        }
		
	    public static IProfilesInfoDAL CreateProfilesInfoDAL()
        {

		 string fullClassName = AssemblyNameSpace + ".ProfilesInfoDAL";
          return CreateInstance(fullClassName) as IProfilesInfoDAL;

        }
		
	    public static IStoreInfoDAL CreateStoreInfoDAL()
        {

		 string fullClassName = AssemblyNameSpace + ".StoreInfoDAL";
          return CreateInstance(fullClassName) as IStoreInfoDAL;

        }
		
	    public static IsysdiagramsDAL CreatesysdiagramsDAL()
        {

		 string fullClassName = AssemblyNameSpace + ".sysdiagramsDAL";
          return CreateInstance(fullClassName) as IsysdiagramsDAL;

        }
	}
	
}