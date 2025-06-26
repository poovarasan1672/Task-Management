import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskService } from '../../core/task.service';
import { MatCardModule } from '@angular/material/card';
import { Router } from '@angular/router';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

@Component({
  selector: 'app-dashboard',
  standalone:true,
  imports: [CommonModule, MatCardModule,DragDropModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnInit {

  cards = [
    { title: 'Total Tasks', count: 0, class: 'total', filter: 'all' },
    { title: 'Completed', count: 0, class: 'completed', filter: 'completed' },
    { title: 'Pending', count: 0, class: 'pending', filter: 'pending' },
    { title: 'Overdue', count: 0, class: 'overdue', filter: 'overdue' }
  ];

  constructor(private taskService: TaskService, private router: Router) {}

  ngOnInit() {
    this.taskService.getTaskStats().subscribe((res: any) => {
      this.cards[0].count = res.data.totalTasks;
      this.cards[1].count = res.data.completedTasks;
      this.cards[2].count = res.data.pendingTasks;
      this.cards[3].count = res.data.overdueTasks;
    });
  }

  drop(event: CdkDragDrop<any[]>) {
    moveItemInArray(this.cards, event.previousIndex, event.currentIndex);
  }

  navigateToTasks(filter:string){
    this.router.navigate(['/tasks'], { queryParams: { filter } });

  }
}
