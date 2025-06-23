import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../../core/task.service'
import { ToDoTask } from '../../models/todo-task.model';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-task-form',
  standalone:true,
  imports: [ CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatButtonModule],
  templateUrl: './task-form.component.html',
  styleUrl: './task-form.component.scss'
})
export class TaskFormComponent implements OnInit {

  taskForm!: FormGroup;
  isEditMode: boolean = false;
  taskId!: number;

  constructor(
    private fb: FormBuilder,
    private taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.taskForm = this.fb.group({
      taskName: ['', Validators.required],
      dueDate: ['', Validators.required],
      isCompleted: [false],
      projectId: [null, Validators.required]
    });

    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.isEditMode = true;
      this.taskId = Number(idParam);
      this.loadTask(this.taskId);
    }
  }

  loadTask(id: number) {
    this.taskService.getTask(id).subscribe((task:any) => {
      this.taskForm.patchValue({
          taskName: task.data.taskName,
          dueDate: task.data.dueDate?.split('T')[0],
          isCompleted: task.data.isCompleted,
          projectId: task.data.projectId
        });
    });
  }

  onSubmit() {
    if (this.taskForm.invalid) return;

    const task: ToDoTask = this.taskForm.value;

    if (this.isEditMode) {
      this.taskService.updateTask(this.taskId, task).subscribe(() => {
        alert('Task updated!');
        this.router.navigate(['/tasks']);
      });
    } else {
      this.taskService.createTask(task).subscribe(() => {
        alert('Task created!');
        this.router.navigate(['/tasks']);
      });
    }
  }
}
