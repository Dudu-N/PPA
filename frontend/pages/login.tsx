import { Box, Button, TextField, Typography } from '@mui/material';
import {Person} from '@mui/icons-material';
import React, { useState } from 'react';
import CenterBox from '../components/CenterBox';
import { ApiClientService } from '../service/ApiClientService';
import { LoginDto } from '../models';
import { useRouter } from 'next/router';

export default function Login(){

    const apiClient = new ApiClientService();
    const router = useRouter();
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    
    function handleEmailChange(e: any){
        setUsername(e.target.value)
    }

    function handlePasswordChange(e: any){
        setPassword(e.target.value)
    }

    async function handleLogin(){
        const userDetails: LoginDto = {username, password};
        await apiClient.login(userDetails).then((res)=>{
            console.log('Success');
            sessionStorage.setItem('username', JSON.stringify(userDetails.username)); //set the username to the session state
        });
    }

    function handleSignup(){
        router.push('/signup')
    }

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
                            value={username}
                            onChange={handleEmailChange}
                            className="row w-100 m-3"
                            type={'email'}
                            />
                        <TextField 
                            required
                            margin="normal"
                            variant="filled"
                            id="password"
                            label="Password"
                            value={password}
                            onChange={handlePasswordChange}
                            className="row w-100 m-3"
                            type={'password'}
                            />
                            <Button 
                                variant="contained"
                                className="m-4 p-2 w-75 "
                                sx={{borderRadius:2}}
                                onClick={handleLogin}
                                >
                                Login
                            </Button>
                            <Button 
                                variant="text"
                                className="m-4 p-2 text-white "
                                sx={{borderRadius:2}}
                                onClick={handleSignup}
                                endIcon={<Person/>}

                                >
                                Create An Account
                            </Button>
            </Box>
        </CenterBox>
    );
}
