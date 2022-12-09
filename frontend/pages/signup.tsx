import { Box, Button, MenuItem, TextField, Typography } from '@mui/material';
import {Person, ArrowRight} from '@mui/icons-material';
import React, { useEffect, useState } from 'react';
import CenterBox from '../components/CenterBox';
import { ApiClientService } from '../service/ApiClientService';
import { useRouter } from 'next/router';
import { RegisterDto } from '../models';


const defaultRegisterDto = {
    username: '',
    password: '',
    firstName: '',
    lastName: '',
    identityNumber: '',
    age: 18,
    email: '',
    chipNumber: '',
    userRole: 2
}
export default function Signup(){

    const apiClient = new ApiClientService();
    const router = useRouter();
    const [registerDto,setRegisterDto] = useState<RegisterDto>(defaultRegisterDto)
    // @ts-ignore 
    function updateObject(target, value){
        let r = {...registerDto};
        // @ts-ignore 
        r[target] = value;
        setRegisterDto(r);
    }

    async function handleSignup(){
        // router.push('/signup')
        
        return await apiClient.signup(registerDto as RegisterDto).then((res)=> {
            console.log(res);
            router.push('');
        });
    }

    useEffect(()=>{
        const username = sessionStorage.getItem('username') as string //getting the username from the session
        console.log(JSON.parse(username));
        
    },[registerDto])

    return (
        <CenterBox>
             <Box
                component="form"
                sx={{
                    '& .MuiTextField-root': { m: 1,width:'25ch', backgroundColor: 'white', borderRadius:5},
                }}
                noValidate
                >
                <h2 className='text-center my-2' >PPA LOGIN</h2>

                    <TextField 
                        required
                        margin="normal"
                        variant="filled"
                        id="username"
                        label="Username"
                        value={registerDto.username}
                        onChange={(e) => {updateObject('username',e.target.value)}}
                        className="row w-100 m-3"
                        type={'username'}
                    />
                    <TextField 
                        required
                        margin="normal"
                        variant="filled"
                        id="password"
                        label="Password"
                        value={registerDto.password}
                        onChange={(e) => {updateObject('password',e.target.value)}}
                        className="row w-100 m-3"
                        type={'password'}
                    />
                    <TextField 
                        required
                        margin="normal"
                        variant="filled"
                        id="firstName"
                        label="First Name"
                        value={registerDto.firstName}
                        onChange={(e) => {updateObject('firstName',e.target.value)}}
                        className="row w-100 m-3"
                    />
                    <TextField 
                        required
                        margin="normal"
                        variant="filled"
                        id="lastName"
                        label="Last Name"
                        value={registerDto.lastName}
                        onChange={(e) => {updateObject('lastName',e.target.value)}}
                        className="row w-100 m-3"
                    />
                    <TextField 
                        required
                        margin="normal"
                        variant="filled"
                        id="indentityNumber"
                        label="ID Number:"
                        value={registerDto.identityNumber}
                        onChange={(e) => {updateObject('identityNumber',e.target.value)}}
                        className="row w-100 m-3"
                    />
                    <TextField 
                        required
                        margin="normal"
                        variant="filled"
                        id="age"
                        label="Age"
                        value={registerDto.age}
                        onChange={(e) => {updateObject('age',e.target.value)}}
                        className="row w-100 m-3"
                        type={'number'}
                    />
                    <TextField 
                        required
                        margin="normal"
                        variant="filled"
                        id="email"
                        label="Email"
                        value={registerDto.email}
                        onChange={(e) => {updateObject('email',e.target.value)}}
                        className="row w-100 m-3"
                        type={'email'}
                    />
                    <TextField 
                        required
                        margin="normal"
                        variant="filled"
                        id="chipNumber"
                        label="Chip Number"
                        value={registerDto.chipNumber}
                        onChange={(e) => {updateObject('chipNumber',e.target.value)}}
                        className="row w-100 m-3"
                    />
                    
                     <TextField 
                        required
                        select
                        margin="normal"
                        variant="filled"
                        id="userRole"
                        label="User Role"
                        value={registerDto.userRole}
                        onChange={(e) => {updateObject('userRole',e.target.value)}}
                        className="row w-100 m-3"
                    >
                        <MenuItem value={0}>Admin</MenuItem>
                        <MenuItem value={1}>Member</MenuItem>
                        <MenuItem value={2}>Participant</MenuItem>
                    </TextField>
                    <Button 
                        variant="contained"
                        className="m-4 p-2 w-75 "
                        sx={{borderRadius:2}}
                        onClick={handleSignup}
                        >
                        Signup
                    </Button>
            </Box>
        </CenterBox>
    );
}
