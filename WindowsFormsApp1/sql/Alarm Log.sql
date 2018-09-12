SELECT t.node_name, t.system_alarm_code, t.alarm_code, t.alarm_desc,
       t.alarm_eng_desc, t.alarm_type, t.is_stop, t.need_reset, t.time_stamp
  FROM log_alarm_his t
 WHERE time_stamp BETWEEN @from_dt AND @to_dt
 ORDER BY time_stamp 
 LIMIT @limit;