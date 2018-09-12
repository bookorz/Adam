WITH tmp AS( 
 SELECT m.pr_id, m.foup_id, m.slot_list, m.process_cnt, m.create_time,m.time_stamp, d1.event_time AS start_time, 
        (SELECT MAX(event_time) FROM log_process_job_detail t WHERE t.pr_id = m.pr_id ) AS last_update_time
   FROM log_process_job m 
   LEFT JOIN log_process_job_detail d1
     ON d1.event_type = 'Start'
	 AND m.pr_id = d1.pr_id
), tmp2 AS(
SELECT t.pr_id, t.foup_id, t.slot_list, t.process_cnt, t.create_time,
       t.start_time, t.last_update_time, d2.job_status AS last_update_status,t.time_stamp,
       TIME_TO_SEC( timediff(t.last_update_time,t.start_time)) AS process_seconds
  FROM tmp t
  LEFT JOIN log_process_job_detail d2
    ON t.pr_id = d2.pr_id 
   AND t.last_update_time = d2.event_time 
)
SELECT pr_id, foup_id, slot_list, process_cnt, 
       date_format(create_time,'%Y-%m-%d %H:%i:%s.%f') AS create_time,
       date_format(start_time,'%Y-%m-%d %H:%i:%s.%f') AS start_time, 
	   date_format(last_update_time,'%Y-%m-%d %H:%i:%s.%f') AS last_update_time, 
	   last_update_status, process_seconds,
       CASE WHEN last_update_status = 'COMPLETE' THEN ROUND(process_cnt / process_seconds * 3600)
		      ELSE 0 END AS wph
  FROM tmp2
 WHERE time_stamp BETWEEN @from_dt AND @to_dt
   AND foup_id LIKE @cond_1
 ORDER BY create_time, start_time, last_update_time
 LIMIT @limit;