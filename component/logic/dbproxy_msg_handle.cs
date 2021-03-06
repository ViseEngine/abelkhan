﻿using System;
using System.Collections;

namespace logic
{
	public class dbproxy_msg_handle
	{
		public dbproxy_msg_handle(dbproxyproxy dbproxy_, logic _logic_)
		{
			_dbproxy = dbproxy_;
            _logic = _logic_;
        }

		public void reg_logic_sucess()
        {
            log.log.trace(new System.Diagnostics.StackFrame(true), service.timerservice.Tick, "connect dbproxy server sucess");

            _logic.onConnectDB_event();
        }

		public void ack_create_persisted_object(String callbackid)
		{
			dbproxyproxy.onCreatePersistedObjectHandle _handle = (dbproxyproxy.onCreatePersistedObjectHandle)_dbproxy.begin_callback(callbackid);
			_handle();
			_dbproxy.end_callback(callbackid);
		}

		public void ack_updata_persisted_object(String callbackid)
		{
			dbproxyproxy.onUpdataPersistedObjectHandle _handle = (dbproxyproxy.onUpdataPersistedObjectHandle)_dbproxy.begin_callback(callbackid);
			_handle();
			_dbproxy.end_callback(callbackid);
		}

		public void ack_get_object_info(String callbackid, ArrayList obejct_array)
		{
			dbproxyproxy.onGetObjectInfoHandle _handle = (dbproxyproxy.onGetObjectInfoHandle)_dbproxy.begin_callback(callbackid);
			_handle(obejct_array);
		}

		public void ack_get_object_info_end(String callbackid)
		{
            dbproxyproxy.onGetObjectInfoEnd _end = (dbproxyproxy.onGetObjectInfoEnd)_dbproxy.end_get_object_info_callback(callbackid);
            _end();
        }

		private dbproxyproxy _dbproxy;
        private logic _logic;
	}
}

