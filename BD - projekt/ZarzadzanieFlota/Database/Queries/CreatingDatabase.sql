-- Exported from QuickDBD: https://www.quickdatabasediagrams.com/
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.

-- Exported from QuickDBD: https://www.quickdatabasediagrams.com/
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.
-- Exported from QuickDBD: https://www.quickdatabasediagrams.com/
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.
-- Exported from QuickDBD: https://www.quickdatabasediagrams.com/
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.
-- Exported from QuickDBD: https://www.quickdatabasediagrams.com/
-- NOTE! If you have used non-SQL datatypes in your design, you will have to change these here.

SET XACT_ABORT ON

BEGIN TRANSACTION QUICKDBD

CREATE TABLE [Employees] (
    -- Clustered
    -- Clustered
    -- Clustered
    -- Clustered
    [id] int IDENTITY(1,1) NOT NULL ,
    [name] text  NOT NULL ,
    [surname] text  NOT NULL ,
    [phone_no] bigint  NOT NULL ,
    [email] text  NOT NULL ,
    [login] text  NOT NULL ,
    [password] text  NOT NULL ,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [Drivers] (
    -- Clustered
    -- Clustered
    -- Clustered
    -- Clustered
    [id] int  NOT NULL ,
    [avail_vehicle_type] int  NOT NULL ,
    CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [Assignments] (
    -- Clustered
    -- Clustered
    [id] int IDENTITY(1,1) NOT NULL ,
    [id_driver] int  NOT NULL ,
    [id_line] int  NOT NULL ,
    [date] date  NOT NULL ,
    [start_time] time  NOT NULL ,
    [end_time] time  NOT NULL ,
    [id_first_stop] int  NOT NULL ,
    CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [Vehicles] (
    -- Clustered
    -- Clustered
    -- Clustered
    [id] int IDENTITY(1,1) NOT NULL ,
    [reg_no] text  NOT NULL ,
    [side_no] text  NOT NULL ,
    [type] int  NOT NULL ,
    [capacity] int  NOT NULL ,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [Lines] (
    -- Clustered
    [id] int IDENTITY(1,1) NOT NULL ,
    [line_no] int  NOT NULL ,
    [type] int  NOT NULL ,
    CONSTRAINT [PK_Lines] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [Transits] (
    -- Clustered
    -- Clustered
    -- Clustered
    -- Clustered
    [id] int IDENTITY(1,1) NOT NULL ,
    [id_line] int  NOT NULL ,
    [id_first_stop] int  NOT NULL ,
    [id_last_stop] int  NOT NULL ,
    [weekday] text  NOT NULL ,
    [day_type] int  NOT NULL ,
    [start_time] time  NOT NULL ,
    [pref_vehicle_cap] int  NOT NULL ,
    CONSTRAINT [PK_Transits] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [Stops] (
    -- Clustered
    -- Clustered
    -- Clustered
    -- Clustered
    [id] int IDENTITY(1,1) NOT NULL ,
    [name] text  NOT NULL ,
    [district] text  NOT NULL ,
    [stand_no] int  NOT NULL ,
    CONSTRAINT [PK_Stops] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [Stops_on_route] (
    -- Clustered
    -- Clustered
    -- Clustered
    -- Clustered
    [id] int IDENTITY(1,1) NOT NULL ,
    [id_stop] int  NOT NULL ,
    [id_next] int  NOT NULL ,
    [id_prev] int  NOT NULL ,
    [ordinal_no] int  NOT NULL ,
    [transit_time] time  NOT NULL ,
    CONSTRAINT [PK_Stops_on_route] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

CREATE TABLE [Lateness] (
    -- Clustered
    [id_course] int  NOT NULL ,
    -- Clustered
    [id_stop_on_route] int  NOT NULL ,
    [time] time  NOT NULL ,
    CONSTRAINT [PK_Lateness] PRIMARY KEY CLUSTERED (
        [id_course] ASC,[id_stop_on_route] ASC
    )
)

CREATE TABLE [Courses] (
    -- Clustered
    -- Clustered
    -- Clustered
    -- Clustered
    [id] int IDENTITY(1,1) NOT NULL ,
    [id_driver] int  NULL ,
    [id_vehicle] int  NOT NULL ,
    [id_transit] int  NOT NULL ,
    [date] date  NOT NULL ,
    CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED (
        [id] ASC
    )
)

ALTER TABLE [Drivers] WITH CHECK ADD CONSTRAINT [FK_Drivers_id] FOREIGN KEY([id])
REFERENCES [Employees] ([id])

ALTER TABLE [Drivers] CHECK CONSTRAINT [FK_Drivers_id]

ALTER TABLE [Assignments] WITH CHECK ADD CONSTRAINT [FK_Assignments_id_driver] FOREIGN KEY([id_driver])
REFERENCES [Drivers] ([id])

ALTER TABLE [Assignments] CHECK CONSTRAINT [FK_Assignments_id_driver]

ALTER TABLE [Assignments] WITH CHECK ADD CONSTRAINT [FK_Assignments_id_line] FOREIGN KEY([id_line])
REFERENCES [Lines] ([id])

ALTER TABLE [Assignments] CHECK CONSTRAINT [FK_Assignments_id_line]

ALTER TABLE [Assignments] WITH CHECK ADD CONSTRAINT [FK_Assignments_id_first_stop] FOREIGN KEY([id_first_stop])
REFERENCES [Stops_on_route] ([id])

ALTER TABLE [Assignments] CHECK CONSTRAINT [FK_Assignments_id_first_stop]

ALTER TABLE [Transits] WITH CHECK ADD CONSTRAINT [FK_Transits_id_line] FOREIGN KEY([id_line])
REFERENCES [Lines] ([id])

ALTER TABLE [Transits] CHECK CONSTRAINT [FK_Transits_id_line]

ALTER TABLE [Transits] WITH CHECK ADD CONSTRAINT [FK_Transits_id_first_stop] FOREIGN KEY([id_first_stop])
REFERENCES [Stops_on_route] ([id])

ALTER TABLE [Transits] CHECK CONSTRAINT [FK_Transits_id_first_stop]

ALTER TABLE [Transits] WITH CHECK ADD CONSTRAINT [FK_Transits_id_last_stop] FOREIGN KEY([id_last_stop])
REFERENCES [Stops_on_route] ([id])

ALTER TABLE [Transits] CHECK CONSTRAINT [FK_Transits_id_last_stop]

ALTER TABLE [Stops_on_route] WITH CHECK ADD CONSTRAINT [FK_Stops_on_route_id_stop] FOREIGN KEY([id_stop])
REFERENCES [Stops] ([id])

ALTER TABLE [Stops_on_route] CHECK CONSTRAINT [FK_Stops_on_route_id_stop]

ALTER TABLE [Stops_on_route] WITH CHECK ADD CONSTRAINT [FK_Stops_on_route_id_next] FOREIGN KEY([id_next])
REFERENCES [Stops_on_route] ([id])

ALTER TABLE [Stops_on_route] CHECK CONSTRAINT [FK_Stops_on_route_id_next]

ALTER TABLE [Stops_on_route] WITH CHECK ADD CONSTRAINT [FK_Stops_on_route_id_prev] FOREIGN KEY([id_prev])
REFERENCES [Stops_on_route] ([id])

ALTER TABLE [Stops_on_route] CHECK CONSTRAINT [FK_Stops_on_route_id_prev]

ALTER TABLE [Lateness] WITH CHECK ADD CONSTRAINT [FK_Lateness_id_course] FOREIGN KEY([id_course])
REFERENCES [Courses] ([id])

ALTER TABLE [Lateness] CHECK CONSTRAINT [FK_Lateness_id_course]

ALTER TABLE [Lateness] WITH CHECK ADD CONSTRAINT [FK_Lateness_id_stop_on_route] FOREIGN KEY([id_stop_on_route])
REFERENCES [Stops_on_route] ([id])

ALTER TABLE [Lateness] CHECK CONSTRAINT [FK_Lateness_id_stop_on_route]

ALTER TABLE [Courses] WITH CHECK ADD CONSTRAINT [FK_Courses_id_driver] FOREIGN KEY([id_driver])
REFERENCES [Drivers] ([id])

ALTER TABLE [Courses] CHECK CONSTRAINT [FK_Courses_id_driver]

ALTER TABLE [Courses] WITH CHECK ADD CONSTRAINT [FK_Courses_id_vehicle] FOREIGN KEY([id_vehicle])
REFERENCES [Vehicles] ([id])

ALTER TABLE [Courses] CHECK CONSTRAINT [FK_Courses_id_vehicle]

ALTER TABLE [Courses] WITH CHECK ADD CONSTRAINT [FK_Courses_id_transit] FOREIGN KEY([id_transit])
REFERENCES [Transits] ([id])

ALTER TABLE [Courses] CHECK CONSTRAINT [FK_Courses_id_transit]

COMMIT TRANSACTION QUICKDBD