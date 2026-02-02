export interface Employee {
  id: number;
  name: string;
  gender: 'Male' | 'Female';
  department: string;
  email?: string;
  phoneNumber?: number;
  isActive: boolean;
  photoPath: string;
}
