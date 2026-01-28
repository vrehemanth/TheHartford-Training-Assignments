import { Routes } from '@angular/router';
import { Login } from './components/login/login';
import { Layout } from './components/layout/layout';
import { AddEmp } from './components/add-emp/add-emp';
import { ShowEmpById } from './components/show-emp-by-id/show-emp-by-id';
import { ListEmp } from './components/list-emp/list-emp';
import { DeleteEmp } from './components/delete-emp/delete-emp';
import { EditEmp } from './components/edit-emp/edit-emp';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
    },
    {
        path: 'login',
        component: Login
    },
    {
        path: '',
        component: Layout,
        children: [
            {
                path: 'add-emp',
                component: AddEmp
            },
            {
                path: 'edit-emp',
                component: EditEmp
            },
            {
                path: 'delete-emp',
                component: DeleteEmp
            },
            { 
                path: 'list-emp',
                component: ListEmp
            },
            {
                path: 'show-emp-by-id',
                component: ShowEmpById
            },
        ]
    }
];
