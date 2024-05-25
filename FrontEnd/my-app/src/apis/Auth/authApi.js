
import axiosIns from "../../plugins/axios";
import { defineStore } from "pinia";


export const authApi = defineStore("auth", {
  actions: {
    login(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .post('Auth/Login', {
            ...params,
          })
          .then((res) => {
            resolve(res);
          })
          .catch((error) => {
            reject(error);
          });
      });
    },
    register(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .post(`Auth/Register`,
                  {...params,},
                  {
                    headers: {
                      "Content-Type": "multipart/form-data",
                    },
                  }
                )
          .then((res) => {
            resolve(res.data.data);
          })
          .catch((err) => {
            reject(err);
          });
      });
    },
    confirmAddUser(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .put("/Auth/AuthenticateUser", { ...params })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    forgotPassword(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .post("/Auth/XacNhanQuenMatKhau", { ...params })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },updatePassword(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .put("/Auth/UpdatePassword", { ...params })
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    getUserById(id){
      return new Promise((resolve, reject) => {
        axiosIns.get(`Auth/GetUserById/${id}`)
        .then((res) => {
          resolve(res)
        })
        .catch((error) => {
          reject(error)
        })
      })
    }
  },
});
