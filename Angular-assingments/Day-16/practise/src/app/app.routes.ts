import { Routes } from '@angular/router';

import { Calc } from '../components/calc/calc';
import { Imgcfilter } from '../components/imgcfilter/imgcfilter';
import { Imgchange } from '../components/imgchange/imgchange';
import { Insurancecalc } from '../components/insurancecalc/insurancecalc';
import { MessageComponent } from '../components/message/message';
import { Policycompare } from '../components/policycompare/policycompare';
import { Slider } from '../components/slider/slider';
import { TwoWayBinding } from '../components/two-way-binding/two-way-binding';


export const routes: Routes = [
  { path: '', redirectTo: 'employees', pathMatch: 'full' },


  { path: 'calc', component: Calc },
  { path: 'image-filter', component: Imgcfilter },
  { path: 'image-change', component: Imgchange },
  { path: 'insurance', component: Insurancecalc },
  { path: 'messages', component: MessageComponent },
  { path: 'policy', component: Policycompare },
  { path: 'slider', component: Slider },
  { path: 'two-way', component: TwoWayBinding },

  { path: '**', redirectTo: 'employees' }
];
