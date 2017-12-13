@echo off
echo start cleaning
call delete_obj_bin.cmd
echo end cleaning
echo start buld solution
call build_solution.cmd
echo end buld solution
echo start copy files
call copy_files.cmd
echo end copy files
echo create md
call create_md_files.cmd
echo end create md