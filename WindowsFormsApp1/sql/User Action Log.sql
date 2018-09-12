SELECT t.function_type, t.action_type, t.remark, t.action_user,
       date_format(action_time,'%Y-%m-%d %H:%i:%s.%f') AS action_time
  FROM log_system_action t
 WHERE time_stamp BETWEEN @from_dt AND @to_dt
   AND action_user LIKE @cond_1
 ORDER BY action_time
 LIMIT @limit;