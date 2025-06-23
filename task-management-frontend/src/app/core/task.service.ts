import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToDoTask } from '../models/todo-task.model';

@Injectable({ providedIn: 'root' })
export class TaskService {
  
  private baseUrl = 'http://localhost:5177/api';

  constructor(private http: HttpClient) { }

  getAllTasks() {
  return this.http.get(`${this.baseUrl}/Task/AllTasks`)
  }

  getTask(id: number) {
    return this.http.get(`${this.baseUrl}/Task/${id}`);
  }

  createTask(task: ToDoTask) {
    return this.http.post(`${this.baseUrl}/Task`, task);
  }

  updateTask(id: number, task: ToDoTask) {
    return this.http.put(`${this.baseUrl}/Task/${id}`, task);
  }

  deleteTask(id: number){
    return this.http.delete(`${this.baseUrl}/Task/${id}`);
  }

  getTaskStats() {
    return this.http.get(`${this.baseUrl}/Dashboard`);
  }
}
