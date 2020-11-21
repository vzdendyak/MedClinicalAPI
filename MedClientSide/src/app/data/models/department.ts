import {User} from './user';
import {Service} from './service';
import {DepartmentService} from './department-service';
import {Schedule} from './schedule';

export class Department {
  public id: number;
  public departmentName: string;
  public description: string;
  public addressId: number;
  public scheduleId: number;
  public schedule: Schedule;
  public isVisible: boolean;
  public doctors: User[];
  public departmentServices: DepartmentService[];
}
