import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskService } from '../../core/task.service';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-dashboard',
  standalone:true,
  imports: [CommonModule, MatCardModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnInit {

  totalTasks: number = 0;
  completedTasks: number = 0;
  overdueTasks: number = 0;

  constructor(private taskService: TaskService) {}

  ngOnInit() {
    this.taskService.getTaskStats().subscribe((res:any) => {
      this.totalTasks = res.data.totalTasks;
      this.completedTasks = res.data.completedTasks;
      this.overdueTasks = res.data.overdueTasks;
    });
  }
}
