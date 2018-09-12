 SELECT t.dio_name, t.dio_type, t.address,t.parameter, t.new_value, t.old_value,
        date_format(t.event_time,'%Y-%m-%d %H:%i:%s.%f') AS event_time
  FROM log_dio_event t
 WHERE time_stamp BETWEEN @from_dt AND @to_dt
 ORDER BY event_time, t.dio_name, t.dio_type, t.address
 LIMIT @limit;