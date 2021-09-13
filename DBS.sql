/* RATIONAL SCHEMA
HERO(HID, HNAME, MINVALUE, MAXVALUE, USES)
PRIMARY KEY (HID)

VILLAIN(VID, VNAME)
PRIMARY KEY (HID)

GAME(GAMEID)
PRIMARY KEY (GAMEID)

ACTIONS(GAMEID, HID, VID, TURNCOUNTER, DAMAGEDONE)
PRIMARY KEY(HID, VID, GAMEID, TURNCOUNTER)
FOREIGN KEY (GAMEID) REFERENCES GAME
FOREIGN KEY (HID) REFERENCES HERO (HID)
FOREIGN KEY (VID) REFERENCES VILLAIN (VID)

*/

IF OBJECT_ID('HERO') IS NOT NULL
DROP TABLE HERO;

IF OBJECT_ID('VILLAIN') IS NOT NULL
DROP TABLE VILLAIN;

IF OBJECT_ID('GAME') IS NOT NULL
DROP TABLE GAME;

IF OBJECT_ID('ACTIONS') IS NOT NULL
DROP TABLE ACTIONS;

CREATE TABLE HERO (
    HID INT,
    HNAME NVARCHAR(100),
    MINVALUE INT,
    MAXVALUE INT,
    USES INT,
PRIMARY KEY (HID)
);

CREATE TABLE VILLAIN (
    VID INT,
    VNAME NVARCHAR(100),
PRIMARY KEY (VID)
);

CREATE TABLE GAME (
    GAMEID INT,
PRIMARY KEY (GAMEID)
);

CREATE TABLE ACTIONS (
    HID INT,
    VID INT,
    GAMEID INT,
    TURNCOUNTER INT,
PRIMARY KEY(HID, VID, GAMEID, TURNCOUNTER),
FOREIGN KEY (GAMEID) REFERENCES GAME,
FOREIGN KEY (HID) REFERENCES HERO (HID),
FOREIGN KEY (VID) REFERENCES VILLAIN (VID)
);

INSERT INTO HERO(HID, HNAME, MINVALUE, MAXVALUE, USES) VALUES
(1, 'Mr swinburne', 0, 10, 2)

INSERT INTO VILLAIN(vid, vname) VALUES
(1, 'badPerson')