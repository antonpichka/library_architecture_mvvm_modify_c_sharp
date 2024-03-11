@echo off
set "source=build\."
set "destination=build\."

for /r "%source%" %%F in (*) do (
    copy "%%F" "%destination%"
)