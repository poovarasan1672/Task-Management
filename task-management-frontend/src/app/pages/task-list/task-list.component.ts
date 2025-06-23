import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskService } from '../../core/task.service';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { MatDialogModule } from '@angular/material/dialog';
@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatPaginatorModule, MatInputModule, MatFormFieldModule,MatDialogModule],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.scss',
  providers: []
})
export class TaskListComponent implements OnInit {

  displayedColumns: string[] = ['id','taskName', 'dueDate', 'isCompleted', 'projectId', 'actions'];
  dataSource = new MatTableDataSource<any>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor( private router: Router, private dialog: MatDialog, private taskService: TaskService) { }

  ngOnInit(): void {
    this.loadTasks();
  }
  
  loadTasks() {
    this.taskService.getAllTasks().subscribe((res: any) => {
      this.dataSource.data = res.data;
      this.dataSource.paginator = this.paginator;
      this.dataSource.filterPredicate = (data: any, filter: string): boolean => {
        const status = data.isCompleted ? 'completed' : 'pending';
        const dataStr = `
          ${data.taskName} 
          ${data.dueDate} 
          ${status} 
          ${data.id}
        `.toLowerCase();

        return dataStr.includes(filter.trim().toLowerCase());
      };
    });
  }

  applyFilter(event: Event) {
    const filtervalue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filtervalue.trim().toLocaleLowerCase();
  }

  editTask(id: number) {
    this.router.navigate(['/task-form',id]);
  }

  deleteTask(id: number) {
  const dialogRef = this.dialog.open(ConfirmDialogComponent, {
    width: '350px',
    data: 'Are you sure you want to delete this task?'
  });

  dialogRef.afterClosed().subscribe((result: any) => {
    if (result) {
      this.taskService.deleteTask(id).subscribe(() => {
        alert('Task deleted!');
        this.loadTasks(); 
      });
    }
  });
}
}


