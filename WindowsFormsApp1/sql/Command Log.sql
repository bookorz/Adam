WITH tmp AS(
 SELECT * 
   FROM log_cmd_txn
  WHERE time_stamp BETWEEN @from_dt AND @to_dt
    AND ('%' = @cond_1 OR node_type LIKE @cond_1)
    AND ('%' = @cond_2 OR node_name LIKE @cond_2)
  ORDER BY time_stamp
  LIMIT @limit
)
 SELECT m.txn_id, m.node_name, m.node_type,m.cmd_type,
        d.return_type, 
		date_format(d.receive_time,'%Y-%m-%d %H:%i:%s.%f') AS receive_time, 
		d.raw_data, d.return_value, m.txn_status,  
		date_format(m.txn_start_time,'%Y-%m-%d %H:%i:%s.%f') AS txn_start_time, 
		date_format(m.txn_end_time,'%Y-%m-%d %H:%i:%s.%f') AS txn_end_time, 
		m.txn_method, m.txn_position,
		m.txn_slot, m.txn_arm, m.txn_value, m.script_name, m.form_name
   FROM tmp m, log_cmd_txn_detail d
  WHERE m.txn_id = d.txn_id
    AND d.time_stamp BETWEEN @from_dt AND @to_dt
  ORDER BY m.time_stamp, m.txn_start_time, m.txn_id, d.receive_time
  LIMIT @limit;