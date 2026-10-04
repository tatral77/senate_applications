-- Adds a display order to resolution submitters, so a chosen member can be printed first.
-- Database: STUSER3
-- Safe to re-run: each step checks whether it has already been applied.
-- Take a backup (or run inside a test copy) before running on production.

-- 1) Add the column (nullable at first so existing rows are not affected)
IF NOT EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID(N'dbo.RESOLUTION_SUBMITTERS') AND name = N'SORT_ORDER')
BEGIN
    ALTER TABLE dbo.RESOLUTION_SUBMITTERS ADD SORT_ORDER INT NULL;
END
GO

-- 2) Fill it for existing rows, keeping the order they have today
--    (oldest row = 1 within each resolution). Only touches rows that are still NULL.
;WITH ordered AS (
    SELECT RESOLUTION_SUBMITTERS_ID,
           ROW_NUMBER() OVER (PARTITION BY RESOLUTIONS_ID ORDER BY RESOLUTION_SUBMITTERS_ID) AS rn
    FROM dbo.RESOLUTION_SUBMITTERS
)
UPDATE s
SET    s.SORT_ORDER = o.rn
FROM   dbo.RESOLUTION_SUBMITTERS AS s
JOIN   ordered AS o ON o.RESOLUTION_SUBMITTERS_ID = s.RESOLUTION_SUBMITTERS_ID
WHERE  s.SORT_ORDER IS NULL;
GO

-- 3) Default for any row inserted before the stored procedure is updated
IF NOT EXISTS (SELECT 1 FROM sys.default_constraints
               WHERE parent_object_id = OBJECT_ID(N'dbo.RESOLUTION_SUBMITTERS')
                 AND name = N'DF_RESOLUTION_SUBMITTERS_SORT_ORDER')
BEGIN
    ALTER TABLE dbo.RESOLUTION_SUBMITTERS
        ADD CONSTRAINT DF_RESOLUTION_SUBMITTERS_SORT_ORDER DEFAULT (9999) FOR SORT_ORDER;
END
GO

-- 4) Index for the "ORDER BY SORT_ORDER" lookup per resolution
IF NOT EXISTS (SELECT 1 FROM sys.indexes
               WHERE object_id = OBJECT_ID(N'dbo.RESOLUTION_SUBMITTERS') AND name = N'IX_RESOLUTION_SUBMITTERS_RES_SORT')
BEGIN
    CREATE INDEX IX_RESOLUTION_SUBMITTERS_RES_SORT
        ON dbo.RESOLUTION_SUBMITTERS (RESOLUTIONS_ID, SORT_ORDER);
END
GO

-- Check: every row should now have a value, starting at 1 per resolution
SELECT TOP 20 RESOLUTIONS_ID, RESOLUTION_SUBMITTERS_ID, SYSTEM_USERS_ID, SORT_ORDER
FROM   dbo.RESOLUTION_SUBMITTERS
ORDER  BY RESOLUTIONS_ID DESC, SORT_ORDER;

SELECT COUNT(*) AS rows_without_order FROM dbo.RESOLUTION_SUBMITTERS WHERE SORT_ORDER IS NULL;  -- expect 0
