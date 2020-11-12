import {User} from './user';
import {Service} from './service';
import {DepartmentService} from './department-service';

export class Department {
  public id: number;
  public departmentName: string;
  public description: string;
  public addressId: number;
  public scheduleId: number;

  public doctors: User[];
  public departmentServices: DepartmentService[];
}
