SET @a='2'; /* Equipment Number Change */
SET @b='Sony Recorder'; /* Equipment Name Change */
SET @d='Cassette Recorder'; /* Equipment Type/NAME From Table*/
SET @resno='25092016-8424736';
/* Get New Serial of the Changed Equipment and Equipment Number */
SET @new_sn=(SELECT equipmentserial from ceutltdprevmaintenance.equipmentlist where equipmentnumber=@a and equipmentmodel=@b and equipmentname=@d);

/* SET The New Serial Number of the changed equipment */
UPDATE ceutltdscheduler.reservation SET equipmentsn=@new_sn WHERE reservationno=@resno and equipmenttype=@old_eqtype and equipment=@old_equipment and equipmentno=@old_equipmentnumber;
UPDATE ceutltdscheduler.reservation SET equipment=(SELECT equipmentmodel FROM ceutltdprevmaintenance.equipmentlist where equipmentserial=@new_sn),equipmentno=(SELECT equipmentnumber FROM ceutltdprevmaintenance.equipmentlist where equipmentserial=@new_sn) WHERE reservationno=@resno and equipmenttype=@old_eqtype and equipment=@old_equipment and equipmentno=@old_equipmentnumber;

UPDATE cuetltdscheduler.reservation_equipments SET equipmentsn=@new_sn, equipment=(SELECT equipmentmodel FROM ceutltdprevmaintenance.equipmentlist where equipmentserial=@new_sn), equipmentno=(SELECT equipmentnumber FROM ceutltdprevmaintenance.equipmentlist where equipmentserial=@new_sn) WHERE reservationno=@resno;