Use `rmsapp`;
ALTER TABLE ReservationDetails
    CHANGE AcceptedCheckIn ExpectedCheckIn DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CHANGE AcceptedCheckOut ExpectedCheckOut DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP;

ALTER TABLE roombookingdto
    ADD COLUMN RoomPrice DECIMAL(10, 2) NOT NULL DEFAULT 0.00;

ALTER TABLE paymentdetailsdto
    CHANGE COLUMN DiscountReason DiscountReason INT;

ALTER TABLE ReservationDetails 
MODIFY COLUMN BookingType INT NULL;

ALTER TABLE paymentdetailsdto
MODIFY COLUMN DiscountReason VARCHAR(255) NULL;
UPDATE paymentdetailsdto
SET DiscountReason = NULL
WHERE DiscountReason = '';
ALTER TABLE paymentdetailsdto
MODIFY COLUMN DiscountReason INT NULL;

ALTER TABLE paymentdetailsdto 
ADD COLUMN isDiscountInPercentage BOOLEAN DEFAULT TRUE,
ADD COLUMN isCommissionInPercentage BOOLEAN DEFAULT TRUE;



ALTER TABLE paymentdetailsdto
MODIFY COLUMN DiscountReason INT NULL,  -- Assuming enum values are stored as INT
ADD COLUMN isDiscountInPercentage BOOLEAN DEFAULT TRUE,
ADD COLUMN isCommissionInPercentage BOOLEAN DEFAULT TRUE;

