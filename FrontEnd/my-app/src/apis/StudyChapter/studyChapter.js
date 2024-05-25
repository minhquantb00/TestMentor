import axiosIns from "../../plugins/axios";
import { defineStore } from "pinia";

const authorization = localStorage.getItem("accessToken")
  ? localStorage.getItem("accessToken")
  : "";
export const studyChapter = defineStore("studyChapter", {
  actions: {
    createStudyChapter(params) {
      return new Promise((resolve, reject) => {
        axiosIns
          .post(
            "/User/CreateChapter",
            { ...params },
            {
              headers: {
                "Content-Type": "multipart/form-data",
                Authorization: `Bearer ${authorization}`,
              },
            }
          )
          .then((res) => resolve(res))
          .catch((error) => reject(error));
      });
    },
    getAllStudyChapter() {
      return new Promise((resolve, reject) => {
        axiosIns
          .get("/user/GetAlls")
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
              console.log(res);
            }else{
              reject(error)
            }
          })
          .catch((error) => reject(error));
      });
      
    },
    getStudyChapterById(id) {
      return new Promise((resolve, reject) => {
        axiosIns
          .get(`/User/GetChapterById/${id}`)
          .then((res) => {
            if (res.status === 200) {
              resolve(res.data);
              console.log(res);
            }else{
              reject(error)
            }
          })
          .catch((error) => reject(error));
      });
      
    },
  },
});
