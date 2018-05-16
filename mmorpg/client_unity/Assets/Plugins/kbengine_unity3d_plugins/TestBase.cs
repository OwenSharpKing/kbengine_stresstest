/*
	Generated by KBEngine!
	Please do not modify this file!
	Please inherit this module, such as: (class Test : TestBase)
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	// defined in */scripts/entity_defs/Test.def
	public abstract class TestBase : EntityComponent
	{
		public Int32 own = 1001;
		public virtual void onOwnChanged(Int32 oldValue) {}
		public Int32 state = 100;
		public virtual void onStateChanged(Int32 oldValue) {}

		public abstract void helloCB(Int32 arg1); 

		public override void onRemoteMethodCall(UInt16 methodUtype, MemoryStream stream)
		{
			ScriptModule sm = EntityDef.moduledefs["Test"];

			Method method = sm.idmethods[methodUtype];
			switch(method.methodUtype)
			{
				case 28:
					Int32 helloCB_arg1 = stream.readInt32();
					helloCB(helloCB_arg1);
					break;
				default:
					break;
			};
		}

		public override void onUpdatePropertys(UInt16 propUtype, MemoryStream stream, int maxCount)
		{
			ScriptModule sm = EntityDef.moduledefs["Test"];
			Dictionary<UInt16, Property> pdatas = sm.idpropertys;

			while(stream.length() > 0 && maxCount-- != 0)
			{
				UInt16 _t_utype = 0;
				UInt16 _t_child_utype = propUtype;

				if(_t_child_utype == 0)
				{
					if(sm.usePropertyDescrAlias)
					{
						_t_utype = stream.readUint8();
						_t_child_utype = stream.readUint8();
					}
					else
					{
						_t_utype = stream.readUint16();
						_t_child_utype = stream.readUint16();
					}
				}

				Property prop = null;

				prop = pdatas[_t_child_utype];

				switch(prop.properUtype)
				{
					case 19:
						Int32 oldval_own = own;
						own = stream.readInt32();

						if(prop.isBase())
						{
							if(owner.inited)
								onOwnChanged(oldval_own);
						}
						else
						{
							if(owner.inWorld)
								onOwnChanged(oldval_own);
						}

						break;
					case 18:
						Int32 oldval_state = state;
						state = stream.readInt32();

						if(prop.isBase())
						{
							if(owner.inited)
								onStateChanged(oldval_state);
						}
						else
						{
							if(owner.inWorld)
								onStateChanged(oldval_state);
						}

						break;
					default:
						break;
				};
			}
		}

		public override void callPropertysSetMethods()
		{
			ScriptModule sm = EntityDef.moduledefs["Test"];
			Dictionary<UInt16, Property> pdatas = sm.idpropertys;

			Int32 oldval_own = own;
			Property prop_own = pdatas[4];
			if(prop_own.isBase())
			{
				if(owner.inited && !owner.inWorld)
					onOwnChanged(oldval_own);
			}
			else
			{
				if(owner.inWorld)
				{
					if(prop_own.isOwnerOnly() && !owner.isPlayer())
					{
					}
					else
					{
						onOwnChanged(oldval_own);
					}
				}
			}

			Int32 oldval_state = state;
			Property prop_state = pdatas[5];
			if(prop_state.isBase())
			{
				if(owner.inited && !owner.inWorld)
					onStateChanged(oldval_state);
			}
			else
			{
				if(owner.inWorld)
				{
					if(prop_state.isOwnerOnly() && !owner.isPlayer())
					{
					}
					else
					{
						onStateChanged(oldval_state);
					}
				}
			}

		}
	}
}