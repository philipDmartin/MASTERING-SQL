SELECT* FROM vehicles;

CALL sp_vehicle_sold(1);
CALL sp_vehicle_returned(1);


CREATE PROCEDURE sp_vehicle_sold(IN sale_id INT)
LANGUAGE plpgsql
AS $$
begin

-- mark car as sold in vehicles

UPDATE vehicle v
SET is_sold = true
WHERE v.vehicle_id = vehicleId;

END
$$;


CREATE PROCEDURE sp_vehicle_returned(IN vin varchar)
LANGUAGE plpgsql
AS $$
begin

-- update vehicle is_sold to false

UPDATE vehicle v
SET is_sold = false
WHERE v.vin = vin;

-- update sale return to true

UPDATE sales s
SET sale_returned = true
WHERE s.vehicle_id = vehicleId;

-- insert into oil change log

INSERT INTO oilchangelogs(vehicle_id, date_occured)
	VALUES(vehicleId, current_date);

END
$$;

