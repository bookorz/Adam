SELECT s.pr_id, s.host_id, s.from_position, s.from_position_slot,
       s.to_position, s.to_position_slot, s.from_foup_id, s.to_foup_id,
       s.job_status, s.ocr_result, s.ocr_path, 
	   date_format(s.create_time,'%Y-%m-%d %H:%i:%s.%f') AS create_time,
	   date_format(s.start_time,'%Y-%m-%d %H:%i:%s.%f') AS start_time,
	   date_format(s.end_time,'%Y-%m-%d %H:%i:%s.%f') AS end_time
  FROM log_process_job_substrate s
 WHERE time_stamp BETWEEN @from_dt AND @to_dt 
   AND host_id LIKE @cond_1
   AND from_foup_id LIKE @cond_2
   AND to_foup_id LIKE @cond_3
 ORDER BY s.create_time, s.start_time, s.end_time
 LIMIT @limit;