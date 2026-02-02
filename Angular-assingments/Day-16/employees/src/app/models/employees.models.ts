export interface Employee {
  id: number;
  name: string;
  gender: 'Male' | 'Female';
  contactPreference: 'Email' | 'Phone';
  email?: string;
  phoneNumber?: number;
  dateOfBirth: Date;
  department: string;
  isActive: boolean;
  photoPath: string;
}
