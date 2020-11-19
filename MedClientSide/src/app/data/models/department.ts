import {User} from './user';

export class Department {
  public id: number;
  public departmentName: string;
  public description: string;
  public addressId: number;
  public scheduleId: number;

  public doctors: User[];
}